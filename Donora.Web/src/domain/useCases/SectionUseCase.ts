import { SectionEntity } from "../entities/SectionEntity";
import type { ISectionRepository } from "../repositories/ISectionRepository";

export class SectionUseCase {
    constructor(
        private readonly repository: ISectionRepository
    ) {}

    async getAll() {
        return await this.repository.getAll();
    }

    async create(name: string,description: string) {
        const section = new SectionEntity(
            0,
            name,
            description,
            "system"
        );

        return await this.repository.create(section);
    }

    async update(
        id: number,
        name: string,
        description: string
    ) {
        const section = new SectionEntity(
            id,
            name,
            description,
            "system"
        );

        return await this.repository.update(section);
    }

    async delete(id: number) {
        return await this.repository.delete(id);
    }
}