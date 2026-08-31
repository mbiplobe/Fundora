
import { Link, useLocation } from "react-router-dom";
import {
    LayoutDashboard,
    GraduationCap,
    FolderOpen,
    Users
} from "lucide-react";

export default function Sidebar() {
    const location = useLocation();

    const menus = [
        {
            title: "Dashboard",
            icon: LayoutDashboard,
            path: "/dashboard"
        },
        {
            title: "Classes",
            icon: GraduationCap,
            path: "/classes"
        },
        {
            title: "Sections",
            icon: FolderOpen,
            path: "/sections"
        },
        {
            title: "Students",
            icon: Users,
            path: "/students"
        }
    ];

    return (
        <aside className="w-64 bg-slate-900 text-white">
            <div className="border-b border-slate-700 p-6">
                <h1 className="text-2xl font-bold">
                    Donora
                </h1>
            </div>

            <nav className="p-4">
                {menus.map((menu) => {
                    const Icon = menu.icon;

                    return (
                        <Link
                            key={menu.path}
                            to={menu.path}
                            className={`mb-2 flex items-center gap-3 rounded-lg px-4 py-3 transition ${
                                location.pathname === menu.path
                                    ? "bg-blue-600"
                                    : "hover:bg-slate-800"
                            }`}
                        >
                            <Icon size={18} />
                            {menu.title}
                        </Link>
                    );
                })}
            </nav>
        </aside>
    );
}
