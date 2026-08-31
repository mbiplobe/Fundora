
import type { IClassRepository } from "../repositories/IClassRepository";
import { ClassEntity } from "../entities/ClassEntity";

export class ClassUseCase {
    constructor(
        private readonly repository: IClassRepository
    ) {}

    async getAll() {
        return await this.repository.getAll();
    }

    async create(name: string, description : string) {
        const item = new ClassEntity(
            0,
            name,
            description,
            "system"
        );

        return await this.repository.create(item);
    }

    async update(
        id: number,
        name: string,
        description: string
    ) {
        const item = new ClassEntity(
            id,
            name,
            description,
            "system"
        );

        return await this.repository.update(item);
    }

    async delete(id: number) {
        return await this.repository.delete(id);
    }
}