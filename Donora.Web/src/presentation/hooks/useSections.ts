import { useEffect, useState } from "react";
import type { SectionDto }
    from "../../infrastructure/dto/SectionDto";
import { objSectionUseCase } from "../../core/di/container";


export const useSections = () => {
    const [sections, setSections] =
        useState<SectionDto[]>([]);

    const load = async () => {
        const data =
            await objSectionUseCase.getAll();

        setSections(data);
    };

    const create = async (
        name: string,
        description: string
    ) => {
        await objSectionUseCase.create(name,description);

        await load();
    };

    const update = async (
        id: number,
        name: string,
        description: string
    ) => {
        await objSectionUseCase.update(
            id,
            name,
            description
        );

        await load();
    };

    const remove = async (
        id: number
    ) => {
        await objSectionUseCase.delete(id);

        await load();
    };

    useEffect(() => {
        // eslint-disable-next-line react-hooks/set-state-in-effect
        load();
    }, []);

    return {
        sections,
        reload: load,
        create,
        update,
        remove
    };
};

