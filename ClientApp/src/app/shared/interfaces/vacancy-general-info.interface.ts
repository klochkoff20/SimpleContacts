import { BasicInfo } from './basic-info.interface';

export interface VacancyGeneralInfo extends BasicInfo<string> {
  department: BasicInfo<string>;
  project: BasicInfo<string>;
  priority: string;
  targetDate: string;
  salary: string;
  responsibleUser: BasicInfo<string>;
  status: number;
}
