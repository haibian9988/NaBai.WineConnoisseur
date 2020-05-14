import { action, observable } from 'mobx';

import CreateWineInput from '../services/wine/dto/createWineInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllWineOutput } from '../services/wine/dto/getAllWineOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedWineResultRequestDto } from '../services/wine/dto/PagedWineResultRequestDto';
import WineModel from '../models/Wine/WineModel';
import UpdateWineInput from '../services/wine/dto/updateWineInput';
import wineService from '../services/wine/wineService';

class WineStore {
    @observable wine!: PagedResultDto<GetAllWineOutput>;
    @observable wineModel: WineModel = new WineModel();

  @action
  async create(createWineInput: CreateWineInput) {
    await wineService.create(createWineInput);
  }

  @action
  async createWine() {
      this.wineModel = {
      id: 0,
      isActive: true,
      name: '',
      tenancyName: '',
    };
  }

  @action
  async update(updateWineInput: UpdateWineInput) {
    let result = await wineService.update(updateWineInput);

      this.wine.items = this.wine.items.map((x: GetAllWineOutput) => {
      if (x.id === updateWineInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await wineService.delete(entityDto);
      this.wine.items = this.wine.items.filter((x: GetAllWineOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await wineService.get(entityDto);
    this.wineModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedWineResultRequestDto) {
    let result = await wineService.getAll(pagedFilterAndSortedRequest);
      this.wine = result;
  }
}

export default WineStore;
