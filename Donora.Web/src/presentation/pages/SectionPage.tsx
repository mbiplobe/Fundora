import { useState } from "react";
import {
    Plus,
    Pencil,
    Trash2,
    FolderOpen
} from "lucide-react";
import { useForm } from "react-hook-form";

import { useSections } from "../hooks/useSections";
import type { SectionDto } from "../../infrastructure/dto/SectionDto";

type SectionForm = {
    name: string;
    description: string;
};

export default function SectionPage() {
    const {
        sections,
        create,
        update,
        remove
    } = useSections();

    const [editingId, setEditingId] =
        useState<number | null>(null);

    const [error, setError] =
        useState<string>("");

    const {
        register,
        handleSubmit,
        reset,
        setValue
    } = useForm<SectionForm>({
        defaultValues: {
            name: "",
            description: ""
        }
    });

    const onSubmit = async (
        data: SectionForm
    ) => {
        try {
            setError("");

            if (editingId !== null) {
                await update(
                    editingId,
                    data.name,
                    data.description
                );
            } else {
                await create(
                    data.name,
                    data.description
                );
            }

            reset();
            setEditingId(null);
        } catch (err) {
            if (err instanceof Error) {
                setError(err.message);
            }

            console.error(err);
        }
    };

    const handleEdit = (
        section: SectionDto
    ) => {
        setEditingId(section.id);

        setValue(
            "name",
            section.name
        );

         setValue(
            "description",
            section.description ?? ""
        );

        setError("");
    };

    const handleDelete = async (
        id: number
    ) => {
        if (
            !window.confirm(
                "Delete this section?"
            )
        ) {
            return;
        }

        try {
            await remove(id);
        } catch (err) {
            console.error(err);
        }
    };

    const handleCancel = () => {
        reset();

        setEditingId(null);

        setError("");
    };

    return (
        <div className="space-y-6">
            <div>
                <h1 className="text-3xl font-bold text-slate-800">
                    Sections
                </h1>

                <p className="mt-1 text-slate-500">
                    Manage academic sections.
                </p>
            </div>

            <div className="rounded-2xl bg-white p-6 shadow-sm">
                <div className="mb-5 flex items-center gap-2">
                    <Plus size={20} />

                    <h2 className="text-xl font-semibold">
                        {editingId !== null
                            ? "Update Section"
                            : "Add New Section"}
                    </h2>
                </div>

                <form
                    onSubmit={handleSubmit(
                        onSubmit
                    )}
                    className="space-y-4">
                    <div>
                        <input
                            {...register("name")}
                            placeholder="Enter section name"
                            className={`w-full rounded-xl border px-4 py-3 outline-none focus:border-blue-500 ${
                                error
                                    ? "border-red-500"
                                    : "border-slate-300"
                            }`}
                        />

                        {error && (
                            <p className="mt-2 text-sm text-red-600">
                                {error}
                            </p>
                        )}
                    </div>

                    <div>
                        <textarea
                            {...register(
                                "description"
                            )}
                            rows={4}
                            placeholder="Enter class description"
                            className={`w-full rounded-xl border px-4 py-3 outline-none focus:border-blue-500 ${
                                error
                                    ? "border-red-500"
                                    : "border-slate-300"
                            }`}
                        />
                    </div>

                    <div className="flex gap-2">
                        <button
                            type="submit"
                            className="rounded-xl bg-blue-600 px-6 py-3 font-medium text-white transition hover:bg-blue-700"
                        >
                            {editingId !== null
                                ? "Update"
                                : "Save"}
                        </button>

                        {editingId !== null && (
                            <button
                                type="button"
                                onClick={
                                    handleCancel
                                }
                                className="rounded-xl bg-slate-200 px-6 py-3 font-medium text-slate-700 transition hover:bg-slate-300"
                            >
                                Cancel
                            </button>
                        )}
                    </div>
                </form>
            </div>

            <div className="rounded-2xl bg-white shadow-sm">
                <div className="border-b p-6">
                    <div className="flex items-center gap-2">
                        <FolderOpen size={20} />

                        <h2 className="text-xl font-semibold">
                            Section List
                        </h2>
                    </div>
                </div>

                <div className="overflow-x-auto">
                    <table className="w-full">
                        <thead>
                            <tr className="bg-slate-50">
                                <th className="px-6 py-4 text-left">
                                    ID
                                </th>

                                <th className="px-6 py-4 text-left">
                                    Name
                                </th>

                                <th className="px-6 py-4 text-left">
                                    Description
                                </th>

                                <th className="px-6 py-4 text-center">
                                    Actions
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            {sections.length ===
                            0 ? (
                                <tr>
                                    <td
                                        colSpan={
                                            3
                                        }
                                        className="py-10 text-center text-slate-500"
                                    >
                                        No sections found.
                                    </td>
                                </tr>
                            ) : (
                                sections.map(
                                    (
                                        section
                                    ) => (
                                        <tr
                                            key={
                                                section.id
                                            }
                                            className="border-t hover:bg-slate-50"
                                        >
                                            <td className="px-6 py-4">
                                                {
                                                    section.id
                                                }
                                            </td>

                                            <td className="px-6 py-4 font-medium">
                                                {
                                                    section.name
                                                }
                                            </td>
                                            <td className="px-6 py-4 font-medium">
                                                {
                                                    section.description
                                                }
                                            </td>

                                            <td className="px-6 py-4">
                                                <div className="flex justify-center gap-2">
                                                    <button
                                                        type="button"
                                                        onClick={() =>
                                                            handleEdit(
                                                                section
                                                            )
                                                        }
                                                        className="rounded-lg bg-amber-500 p-2 text-white hover:bg-amber-600"
                                                    >
                                                        <Pencil size={16} />
                                                    </button>

                                                    <button
                                                        type="button"
                                                        onClick={() =>
                                                            handleDelete(
                                                                section.id
                                                            )
                                                        }
                                                        className="rounded-lg bg-red-500 p-2 text-white hover:bg-red-600"
                                                    >
                                                        <Trash2 size={16} />
                                                    </button>
                                                </div>
                                            </td>
                                        </tr>
                                    )
                                )
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}
