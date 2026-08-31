export class ClassEntity {
    constructor(
        public readonly id: number,
        public readonly name: string,
         public readonly description: string,
        public readonly createdBy: string
    ) {
        if (!name.trim()) {
            throw new Error(
                "class name is required."
            );
        }

        if (name.length > 50) {
            throw new Error(
                "class name cannot exceed 100 characters."
            );
        }

        if (!description.trim()) {
            throw new Error(
                "Description is required."
            );
        }

        if (description.length > 500) {
            throw new Error(
                "Description cannot exceed 500 characters."
            );
        }
    }
}