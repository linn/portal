import React from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
// import useSignIn from '../hooks/useSignIn';
import App from './App';
// import 'typeface-roboto';

function Root() {
    // useSignIn();

    return (
        <Routes>
            <Route path="/" element={<Navigate to="/portal" replace />} />
            <Route path="/portal" element={<App />} />
        </Routes>
    );
}

export default Root;
