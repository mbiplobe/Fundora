import { useEffect, useState } from "react";
import type { ClassDto } from "../../infrastructure/dto/ClassDto";
import { objClassUseCase } from "../../core/di/container";

export const useClasses = () => {
    const [classes, setClasses] =
        useState<ClassDto[]>([]);

    const load = async () => {
        const data =
            await objClassUseCase.getAll();

        setClasses(data);
    };

    const create = async (
        name: string,
        description: string
    ) => {
        await objClassUseCase.create(
            name,
            description
        );

        await load();
    };

    const update = async (
        id: number,
        name: string,
        description: string
    ) => {
        await objClassUseCase.update(
            id,
            name,
            description
        );

        await load();
    };

    const remove = async (
        id: number
    ) => {
        await objClassUseCase.delete(id);

        await load();
    };

    useEffect(() => {
        // eslint-disable-next-line react-hooks/set-state-in-effect
        load();
    }, []);

    return {
        classes,
        reload: load,
        create,
        update,
        remove
    };
};