import CreateWineInput from './dto/createWineInput';
import CreateWineOutput from './dto/createWineOutput';
import { EntityDto } from '../../services/dto/entityDto';
import { GetAllWineOutput } from './dto/getAllWineOutput';
import GetWineOutput from './dto/getWineOutput';
import { PagedResultDto } from '../../services/dto/pagedResultDto';
import {PagedWineResultRequestDto} from './dto/PagedWineResultRequestDto';
import UpdateWineInput from './dto/updateWineInput';
import UpdateWineOutput from './dto/updateWineOutput';
import http from '../httpService';

class WineService {
  public async create(createWineInput: CreateWineInput): Promise<CreateWineOutput> {
    let result = await http.post('api/services/app/Wine/Create', createWineInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Wine/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetWineOutput> {
    let result = await http.get('api/services/app/Wine/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedWineResultRequestDto): Promise<PagedResultDto<GetAllWineOutput>> {
    let result = await http.get('api/services/app/Wine/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateWineInput: UpdateWineInput): Promise<UpdateWineOutput> {
    let result = await http.put('api/services/app/Wine/Update', updateWineInput);
    return result.data.result;
  }
}

export default new WineService();
