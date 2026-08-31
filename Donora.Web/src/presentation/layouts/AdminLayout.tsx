import { Outlet } from "react-router-dom";
import Sidebar from "../../infrastructure/components/Sidebar";

export default function AdminLayout() {
    return (
        <div className="flex min-h-screen bg-slate-100">
            {/* Sidebar */}
            <Sidebar />

            {/* Content Area */}
            <div className="flex flex-1 flex-col">
                {/* Topbar */}
                <header className="flex h-16 items-center justify-between border-b border-slate-200 bg-white px-6 shadow-sm">
                    <div>
                        <h1 className="text-xl font-semibold text-slate-800">
                            Donora
                        </h1>
                    </div>

                    <div className="flex items-center gap-3">
                        <div className="flex h-10 w-10 items-center justify-center rounded-full bg-blue-600 font-semibold text-white">
                            A
                        </div>

                        <div>
                            <p className="font-medium text-slate-800">
                                Administrator
                            </p>

                            <p className="text-sm text-slate-500">
                                System Admin
                            </p>
                        </div>
                    </div>
                </header>

                {/* Page Content */}
                <main className="flex-1 overflow-auto p-6">
                    <Outlet />
                </main>
            </div>
        </div>
    );
}