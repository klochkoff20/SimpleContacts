export interface VacancyUpdate {
  name: string;
  departmentId: string;
  project: string;
  priority?: number;
  employmentType: number;
  location: string;
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
