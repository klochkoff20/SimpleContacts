import { BasicInfo } from './basic-info.interface';

export interface CandidateGeneralInfo extends BasicInfo<string> {
  desiredPosition: string;
  level: number;
  addingDate: string;
  addingSource: string;
  status: number;
  lastActivity: string;
  skills: string[];
}
