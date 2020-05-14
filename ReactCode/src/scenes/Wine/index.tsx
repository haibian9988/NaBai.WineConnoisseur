import * as React from 'react';

import {  Card, Col,  Input,  Modal, Row, Table } from 'antd';
import { inject, observer } from 'mobx-react';

import AppComponentBase from '../../components/AppComponentBase';
import { EntityDto } from '../../services/dto/entityDto';
import { L } from '../../lib/abpUtility';
import Stores from '../../stores/storeIdentifier';
import WineStore from '../../stores/wineStore';

export interface IWineProps {
  wineStore: WineStore;
}

export interface IWineState {
  modalVisible: boolean;
  maxResultCount: number;
  skipCount: number;
  tenantId: number;
  filter: string;
}

const confirm = Modal.confirm;
const Search = Input.Search;

@inject(Stores.WineStore)
@observer
class Wine extends AppComponentBase<IWineProps, IWineState> {
  formRef: any;

  state = {
    modalVisible: false,
    maxResultCount: 10,
    skipCount: 0,
    tenantId: 0,
    filter: '',
  };

  async componentDidMount() {
    await this.getAll();
  }

  async getAll() {
      await this.props.wineStore.getAll({ maxResultCount: this.state.maxResultCount, skipCount: this.state.skipCount, keyword: this.state.filter });
  }

  handleTableChange = (pagination: any) => {
    this.setState({ skipCount: (pagination.current - 1) * this.state.maxResultCount! }, async () => await this.getAll());
  };

  Modal = () => {
    this.setState({
      modalVisible: !this.state.modalVisible,
    });
  };

  async createOrUpdateModalOpen(entityDto: EntityDto) {
    if (entityDto.id === 0) {
        this.props.wineStore.createWine();
    } else {
        await this.props.wineStore.get(entityDto);
    }

    this.setState({ tenantId: entityDto.id });
    this.Modal();

    if (entityDto.id !== 0) {
      this.formRef.props.form.setFieldsValue({
          ...this.props.wineStore.wineModel,
      });
    } else {
      this.formRef.props.form.resetFields();
    }
  }

  delete(input: EntityDto) {
    const self = this;
    confirm({
      title: 'Do you Want to delete these items?',
      onOk() {
          self.props.wineStore.delete(input);
      },
      onCancel() {},
    });
  }

  handleCreate = () => {
    const form = this.formRef.props.form;
    form.validateFields(async (err: any, values: any) => {
      if (err) {
        return;
      } else {
        if (this.state.tenantId === 0) {
            await this.props.wineStore.create(values);
        } else {
            await this.props.wineStore.update({ id: this.state.tenantId, ...values });
        }
      }

      await this.getAll();
      this.setState({ modalVisible: false });
      form.resetFields();
    });
  };

  saveFormRef = (formRef: any) => {
    this.formRef = formRef;
  };

  handleSearch = (value: string) => {
    this.setState({ filter: value }, async () => await this.getAll());
  };

  public render() {
      const { wine } = this.props.wineStore;
      const columns = [
       
        { title: L('Variety'), dataIndex: 'variety', key: 'variety', render: (text: string, item: any) => <div title={item.description}>{text}</div> },
        { title: L('Title'), dataIndex: 'title', key: 'title',  },
        { title: L('Winery'), dataIndex: 'winery', key: 'winery',  },
        { title: L('Producer'), dataIndex: 'producer', key: 'producer',  },
        { title: L('Price'), dataIndex: 'price', key: 'price'},
        { title: L('Points'), dataIndex: 'points', key: 'points' },
        { title: L('Taster_name'), dataIndex: 'taster_name', key: 'taster_name' },
        { title: L('Taster_twitter_handle'), dataIndex: 'taster_twitter_handle', key: 'taster_twitter_handle' },
      
    ];

    return (
      <Card>
        <Row>
          <Col
            xs={{ span: 4, offset: 0 }}
            sm={{ span: 4, offset: 0 }}
            md={{ span: 4, offset: 0 }}
            lg={{ span: 2, offset: 0 }}
            xl={{ span: 2, offset: 0 }}
            xxl={{ span: 2, offset: 0 }}
          >
            <h2>{L('Wine')}</h2>
          </Col>
          <Col
            xs={{ span: 14, offset: 0 }}
            sm={{ span: 15, offset: 0 }}
            md={{ span: 15, offset: 0 }}
            lg={{ span: 1, offset: 21 }}
            xl={{ span: 1, offset: 21 }}
            xxl={{ span: 1, offset: 21 }}
          >
          
          </Col>
        </Row>
        <Row>
          <Col sm={{ span: 9, offset: 0 }}>
                    <Search placeholder={this.L('Producer Filter')} onSearch={this.handleSearch} />
                </Col>
                
        </Row>
        <Row style={{ marginTop: 20 }}>
          <Col
            xs={{ span: 24, offset: 0 }}
            sm={{ span: 24, offset: 0 }}
            md={{ span: 24, offset: 0 }}
            lg={{ span: 24, offset: 0 }}
            xl={{ span: 24, offset: 0 }}
            xxl={{ span: 24, offset: 0 }}
          >
            <Table
              rowKey="id"
              size={'default'}
              bordered={true}
                        pagination={{ pageSize: this.state.maxResultCount, total: wine === undefined ? 0 : wine.totalCount, defaultCurrent: 1 }}
              columns={columns}
                        loading={wine === undefined ? true : false}
                        dataSource={wine === undefined ? [] : wine.items}
              onChange={this.handleTableChange}
            />
          </Col>
        </Row>
    
      </Card>
    );
  }
}

export default Wine;
