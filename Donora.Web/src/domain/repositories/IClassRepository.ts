import type { ClassDto } from "../../infrastructure/dto/ClassDto";
import type { ClassEntity } from "../entities/ClassEntity";

export interface IClassRepository {
    getAll(): Promise<ClassDto[]>;
    create(item : ClassEntity): Promise<boolean>;
    update(item: ClassEntity): Promise<boolean>;
    delete(id: number): Promise<boolean>;
}