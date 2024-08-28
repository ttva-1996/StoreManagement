import { useEffect, useState } from "react";
import { getToken, removeToken } from "../../utils/localStorage.helper";
import { useNavigate } from "react-router-dom";
import { ROUTE } from "../../constants/route.constant";

const HomeComponent: React.FC = () => {
  const navigate = useNavigate();
  const [isLogin, setIsLogin] = useState(false);

  useEffect(() => {
    if (getToken()) {
      setIsLogin(true);
    }
  }, []);

  const handleLogout = () => {
    removeToken();
    window.location.reload();
  };

  return (
    <div>
      <h1>Welcome to the Home Page</h1>
      {isLogin ? (
        <>
          <button onClick={handleLogout}>Logout</button> &nbsp;
          <button onClick={() => navigate(ROUTE.Staff)}>Staff page</button>
        </>
      ) : (
        <button onClick={() => navigate(ROUTE.Login)}>Login</button>
      )}
    </div>
  );
};

export default HomeComponent;
