import { BasicInfo } from './basic-info.interface';

export interface Candidate extends BasicInfo<string> {
  firstName: string;
  lastName: string;
  dateOfBirth?: Date;
  gender: number;
  location: string;
  readyToRelocate: boolean;
  languages: string;
  industry: string;
  experience: number;
  currentWork: string;
  currentPosition: string;
  employmentType: number;
  education: string;
  desiredPosition: string;
  desiredSalary: number;
  phoneNumber: string;
  email: string;
  skype: string;
  linkedIn: string;
  telegram: string;
  facebook: string;
  preferableMethod: number;
  homePage: string;
  status: number;
  source: number;
  skills: string;
  description: string;
  addingDate: Date;
  responsibleUser: BasicInfo<string>;
}
