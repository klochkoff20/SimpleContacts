import { BasicInfo } from '../interfaces';

export const DEPARTMENT_STATUSES: BasicInfo<number>[] = [
  { id: 0, name: 'In Progress' },
  { id: 1, name: 'Future' },
  { id: 2, name: 'On Hold' },
  { id: 3, name: 'All Done' },
  { id: 4, name: 'Canceled' },
  { id: 5, name: 'Deleted' }
];
