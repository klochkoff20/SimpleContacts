import { BasicInfo } from '../interfaces';

export const VACANCY_STATUSES: BasicInfo<number>[] = [
  { id: 0, name: 'New' },
  { id: 1, name: 'In Progress' },
  { id: 2, name: 'On Hold' },
  { id: 3, name: 'Complete' },
  { id: 4, name: 'Canceled' }
];
