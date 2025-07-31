import React from 'react';
import Typography from '@mui/material/Typography';
import { Grid } from '@mui/material';

function LoggedOut() {
    return (
        <Grid container spacing={3}>
            <Grid size={12}>
                <Typography variant="h4">Logged out!!</Typography>
            </Grid>
        </Grid>
    );
}

export default LoggedOut;
