// modules/section/domain/entities/Section.ts

// domain/entities/Section.ts

export class SectionEntity {
    constructor(
        public readonly id: number,
        public readonly name: string,
        public readonly description: string,
        public readonly createdBy: string
    ) {
        if (!name.trim()) {
            throw new Error(
                "Section name is required."
            );
        }

        if (name.length > 50) {
            throw new Error(
                "Section name cannot exceed 50 characters."
            );
        }
        if (!description.trim()) {
            throw new Error(
                "Section description is required."
            );
        }

        if (description.length > 500) {
            throw new Error(
                "Section description cannot exceed 50 characters."
            );
        }
    }
}