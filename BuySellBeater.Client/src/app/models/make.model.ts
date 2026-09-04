export interface Model {
  id: number;
  name: string;
}

export interface Make {
  id: number;
  name: string;
  models: Model[];
}

export interface Vehicle {
  id?: number;
  make: Make | null;
  model: Model | null;
}
