import React, { useEffect } from 'react';
import { useAuth } from 'react-oidc-context';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import { signOut } from '../helpers/authUtils';

export default function AuthGate({ children }) {
    const auth = useAuth();

    useEffect(() => {
        if (auth.isAuthenticated && window.location.search.includes('code=')) {
            const cleanUrl = window.location.origin + window.location.pathname;
            window.history.replaceState({}, document.title, cleanUrl);
        }
    }, [auth.isAuthenticated]);

    if (!auth.isAuthenticated) {
        return (
            <Box display="flex" justifyContent="center" alignItems="center" height="100vh">
                <Button variant="contained" onClick={() => auth.signinRedirect()}>
                    Sign In / Create Account
                </Button>
            </Box>
        );
    }

    const signOutRedirect = async () => {
        await auth.removeUser();

        signOut();
    };

    return (
        <>
            <Box
                display="flex"
                justifyContent="space-between"
                alignItems="center"
                p={2}
                bgcolor="background.paper"
                boxShadow={1}
            >
                <Typography variant="body1">
                    You are logged in as:{' '}
                    <strong>
                        {auth.user?.profile?.preferred_username || auth.user?.profile?.email}
                    </strong>
                </Typography>
                <Button variant="outlined" onClick={() => signOutRedirect()}>
                    Sign Out
                </Button>
            </Box>

            {children}
        </>
    );
}
