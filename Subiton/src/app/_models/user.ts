import { Photo } from './_photo';

export interface User {
    height?: any;
    furColor?: any;
    weight?: any;
    nature?: any;
    martialStatus?: any;
    description?: any;
    lookingFor?: any;
    interests?: any;
    freeTimeActivities?: any;
    education?: any;
    photos: Photo[];
    photoUrl?: any;
    age: number;
    gender?: any;
    dateOfBirth: Date;
    rasa?: any;
    created: Date;
    lastActive: Date;
    city?: any;
    country?: any;
    id: number;
    animalType: number;
    username: string;
    password?: any;
  }
