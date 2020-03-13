export interface VacancyInsert {
  name: string;
  departmentId: string;
  project: string;
  priority?: number;
  employmentType: number;
  location: string;
  languages: string;
  salaryMin?: number;
  salaryMax?: number;
  targetDate?: Date;
  numberOfPositions?: number;
  requiredExperience?: number;
  requirements: string;
  description: string;
  createdBy: string;
  responsibleBy: string;
  updatedBy: string;
  status?: number;
}
