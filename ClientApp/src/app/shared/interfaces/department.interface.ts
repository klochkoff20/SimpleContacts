import { BasicInfo } from './basic-info.interface';

export interface Department {
  id: string;
  name: string;
  location: string;
  phone: string;
  email: string;
  skype: string;
  status?: number;
  description: string;
  createdBy: BasicInfo<string>;
  createdAt?: Date;
  updatedAt?: Date;
  responsibleBy: BasicInfo<string>;
}
