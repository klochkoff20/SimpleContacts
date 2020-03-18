import { BasicInfo } from './basic-info.interface';

export interface Department {
  id: string;
  name: string;
  location: string;
  phone: string;
  email: string;
  skype: string;
  description: string;
  createdBy: BasicInfo<string>;
  createdAt?: Date;
  updatedAt?: Date;
}
