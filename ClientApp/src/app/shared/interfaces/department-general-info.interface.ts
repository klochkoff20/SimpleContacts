import { BasicInfo } from './basic-info.interface';

export interface DepartmentGeneralInfo extends BasicInfo<string> {
  status: number;
  vacancies: BasicInfo<string>[];
  projects: BasicInfo<string>[];
  responsibleUser: BasicInfo<string>;
  phone: string;
  email: string;
  // contacts: any[];
}
