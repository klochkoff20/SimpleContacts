import { BasicInfo } from './basic-info.interface';

export interface DepartmentGeneralInfo {
  id: string;
  name: string;
  status: number;
  vacancies: BasicInfo<string>[];
  projects: BasicInfo<string>[];
  responsibleUser: BasicInfo<string>;
  phone: string;
  email: string;
  // contacts: any[];
}
