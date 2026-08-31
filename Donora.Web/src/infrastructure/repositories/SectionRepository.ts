import api from "../../core/api/axios";
import type { SectionEntity } from "../../domain/entities/SectionEntity";
import type { ISectionRepository } from "../../domain/repositories/ISectionRepository";
import type { SectionDto } from "../dto/SectionDto";

export class SectionRepository implements ISectionRepository {
  async getAll(): Promise<SectionDto[]> {
    try {
      const response = await api.get<SectionDto[]>("section");
      return response.data;
    } catch (error) {
      console.error("Failed to get sections:", error);
      throw error;
    }
  }

  async create(section: SectionEntity): Promise<boolean> {
    try {
      const response = await api.post("section", {
        name: section.name,
        description: section.description,
        createdBy: section.createdBy,
      });

      return response.data;
    } catch {
      return false;
    }
  }

  async update(section: SectionEntity): Promise<boolean> {
    try {

      const response = await api.put("section", {
        id: section.id,
        name: section.name,
        description: section.description,
        updatedBy: section.createdBy
      });

      return response.data;
    } catch {
      return false;
    }
  }

  async delete(id: number): Promise<boolean> {
    const response = await api.delete("section", {
      data: { id },
    });
    return response.data;
  }
}
