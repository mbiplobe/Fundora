import api from "../../core/api/axios";
import type { ClassEntity } from "../../domain/entities/ClassEntity";
import type { IClassRepository } from "../../domain/repositories/IClassRepository";
import type { ClassDto } from "../dto/ClassDto";

export class ClassRepository implements IClassRepository {
  async getAll(): Promise<ClassDto[]> {
    try {
      const response = await api.get<ClassDto[]>("class");
      return response.data;
    } catch (error) {
      console.error("Failed to get sections:", error);
      throw error;
    }
  }

  async create(item: ClassEntity): Promise<boolean> {
    try {
      const response = await api.post("class", {
        name: item.name,
        description: item.description,
        createdBy: item.createdBy,
      });

      return response.data;
    } catch {
      return false;
    }
  }

  async update(item: ClassEntity): Promise<boolean> {
    try {
      // const response = await api.put(`class/${item.id}`, {
      //   id: item.id,
      //   name: item.name,
      //   description: item.description,
      //   updatedBy: item.createdBy
      // });

const response = await api.put("class", {
  id: item.id,
  name: item.name,
  description: item.description,
  updatedBy: item.createdBy
});

      return response.data;
    } catch (err) {
      console.error("Failed to update class:", err);
      return false;
    }
  }

  async delete(id: number): Promise<boolean> {
    const response = await api.delete("class", {
      data: { id },
    });
    return response.data;
  }
}
