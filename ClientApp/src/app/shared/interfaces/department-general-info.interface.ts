import { BasicInfo } from './basic-info.interface';

export interface DepartmentGeneralInfo {
  id: string;
  name: string;
  vacancies: BasicInfo<string>[];
  projects: BasicInfo<string>[];
  phone: string;
  email: string;
}
