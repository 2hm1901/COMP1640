export interface Student {
    id: number;
    fullName: string;
    email: string;
    teacherName: string;
}

export interface CreateStudent {
    firstName: string;
    lastName: string;
    email: string;
}