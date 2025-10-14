export type ResourceStatus = 'available' | 'occupied' | 'inactive';

export interface BookableResource {
  id: string;
  name: string;
  status: ResourceStatus;
  capacity: number;
}

