import { BasicInfo } from './basic-info.interface';

export interface Vacancy {
  id: string;
  name: string;
  department: BasicInfo<string>;
  project: string;
  priority?: number;
  targetDate: Date;
  employmentType?: number;
  location: string;
  salaryMin?: number;
  salaryMax?: number;
  requiredExperience?: number;
  numberOfPositions?: number;
  createdUser: BasicInfo<string>;
  createdAt: Date;
  responsibleUser: BasicInfo<string>;
  updatedUser: BasicInfo<string>;
  updatedAt: Date;
  requirements: string;
  description: string;
  status?: number;
}
