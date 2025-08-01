const clientId = '64fbgrkkslt1choig1e8km1g45';
const logoutUri = 'http://localhost:3000/portal/logged-out/';

export const oidcConfig = {
    authority: 'https://cognito-idp.eu-west-1.amazonaws.com/eu-west-1_HL1uFEa5R',
    client_id: clientId,
    redirect_uri: 'http://localhost:3000/portal',
    response_type: 'code',
    scope: 'email openid phone',
    post_logout_redirect_uri: logoutUri
};

export const signOut = () => {
    const cognitoDomain = 'https://eu-west-1hl1ufea5r.auth.eu-west-1.amazoncognito.com';

    window.location.href = `${cognitoDomain}/logout?client_id=${clientId}&logout_uri=${encodeURIComponent(logoutUri)}`;
};
