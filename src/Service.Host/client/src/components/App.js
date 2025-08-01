import React, { useState } from 'react';
import Typography from '@mui/material/Typography';
import { Grid } from '@mui/material';
import { useAuth } from 'react-oidc-context';
import useGet from '../hooks/useGet';

function App() {
    const auth = useAuth();

    const { send } = useGet('http://localhost:5050/portal/api/invoices', true);
    const [hasSent, setHasSent] = useState(false);

    if (auth.isAuthenticated && !hasSent) {
        send(1);
        setHasSent(true);
    }

    return (
        <Grid container spacing={3}>
            <Grid size={12}>
                <Typography variant="h4">Portal</Typography>
            </Grid>
        </Grid>
    );
}

export default App;
