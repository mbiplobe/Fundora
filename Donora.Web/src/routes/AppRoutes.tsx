import { Routes, Route, Navigate } from "react-router-dom";

import AdminLayout from "../presentation/layouts/AdminLayout";

import DashboardPage from "../presentation/pages/DashboardPage";
import SectionPage from "../presentation/pages/SectionPage";
import ClassPage from "../presentation/pages/ClassPage";
import StudentPage from "../presentation/pages/StudentPage";

export default function AppRoutes() {
    return (
        <Routes>
            <Route
                path="/"
                element={<AdminLayout />}
            >
                <Route
                    index
                    element={
                        <Navigate
                            to="/dashboard"
                            replace
                        />
                    }
                />

                <Route
                    path="dashboard"
                    element={<DashboardPage />}
                />

                <Route
                    path="classes"
                    element={<ClassPage />}
                />

                <Route
                    path="sections"
                    element={<SectionPage />}
                />

                <Route
                    path="students"
                    element={<StudentPage />}
                />
            </Route>
        </Routes>
    );
}