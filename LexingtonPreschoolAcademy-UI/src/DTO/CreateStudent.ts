import { Classes } from "./Classes";


export interface CreateStudentBody {
    firstName: string;
    lastName: string;
    classes: Classes[]
}