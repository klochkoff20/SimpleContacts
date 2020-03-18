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
  startedPractice?: Date;
  currentWork: string;
  currentPosition: string;
  employmentType: number;
  education: string;
  desiredPosition: string;
  level: number;
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
  skillsAsText: string;
  description: string;
  addingDate: Date;
}
