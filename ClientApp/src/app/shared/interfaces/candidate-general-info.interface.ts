import { BasicInfo } from './basic-info.interface';

export interface CandidateGeneralInfo extends BasicInfo<string> {
  position: string;
  responsibleUser: BasicInfo<string>;
  addingDate: string;
  addingSource: string;
  lastActivity: string;
}
