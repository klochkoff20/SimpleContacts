import { BasicInfo } from './basic-info.interface';

export interface VacancyGeneralInfo extends BasicInfo<string> {
  department: BasicInfo<string>;
  project: string;
  priority: string;
  targetDate: string;
  responsibleUser: BasicInfo<string>;
  status: number;
}
