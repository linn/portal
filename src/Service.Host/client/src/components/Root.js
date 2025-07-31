import React from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
// import useSignIn from '../hooks/useSignIn';
import App from './App';
import AuthGate from './AuthGate';
import LoggedOut from './LoggedOut';
// import 'typeface-roboto';

function Root() {
    // useSignIn();

    return (
        <Routes>
            <Route path="/" element={<Navigate to="/portal" replace />} />
            <Route
                path="/portal"
                element={
                    <AuthGate>
                        <App />
                    </AuthGate>
                }
            />
            <Route path="/portal/logged-out/" element={<LoggedOut />} />
        </Routes>
    );
}

export default Root;
