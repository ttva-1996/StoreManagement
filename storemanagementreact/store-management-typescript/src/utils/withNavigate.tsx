import { useNavigate } from 'react-router-dom';

export function withNavigate(Component: any) {
    return (props: any) => {
        const navigate = useNavigate();
        return <Component {...props} navigate={navigate} />;
    };
}