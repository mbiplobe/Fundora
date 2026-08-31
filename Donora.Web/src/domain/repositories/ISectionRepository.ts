// modules/section/domain/repositories/ISectionRepository.ts

import type { SectionDto } from "../../infrastructure/dto/SectionDto";
import type { SectionEntity } from "../entities/SectionEntity";

export interface ISectionRepository {
    getAll(): Promise<SectionDto[]>;
    create(section : SectionEntity): Promise<boolean>;
    update(section: SectionEntity): Promise<boolean>;
    delete(id: number): Promise<boolean>;
}