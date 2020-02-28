import { BasicInfo } from './basic-info.interface';

export interface CandidateGeneralInfo extends BasicInfo<string> {
  desiredPosition: string;
  responsibleUser: BasicInfo<string>;
  addingDate: string;
  addingSource: string;
  status: number;
  lastActivity: string;
}
