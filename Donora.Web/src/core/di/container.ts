import { ClassUseCase } from "../../domain/useCases/ClassUseCase";
import { SectionUseCase } from "../../domain/useCases/SectionUseCase";
import { ClassRepository } from "../../infrastructure/repositories/ClassRepository";
import { SectionRepository } from "../../infrastructure/repositories/SectionRepository";



const objSectionRepository = new SectionRepository();

export const objSectionUseCase = new SectionUseCase(objSectionRepository);

const objClassRepository = new ClassRepository();

export const objClassUseCase = new ClassUseCase(objClassRepository);