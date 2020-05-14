import { PagedFilterAndSortedRequest } from '../../dto/pagedFilterAndSortedRequest';

export interface PagedWineResultRequestDto extends PagedFilterAndSortedRequest  {
    keyword: string
}
