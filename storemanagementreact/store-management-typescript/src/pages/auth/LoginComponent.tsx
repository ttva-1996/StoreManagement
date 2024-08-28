import { ChangeEvent, Component, FormEvent } from "react";
import AuthServices from "../../services/auth/AuthServices";
import { saveToken } from "../../utils/localStorage.helper";
import { withNavigate } from "../../utils/withNavigate";
import { ROUTE } from "../../constants/route.constant";

interface LoginState {
  username: string;
  password: string;
  error: string;
}

interface LoginProps {
  navigate?: any;
}

class LoginComponent extends Component<LoginProps, LoginState> {
  constructor(props: {}) {
    super(props);
    this.state = {
      username: "",
      password: "",
      error: "",
    };
  }

  handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    this.setState({ [name]: value } as Pick<LoginState, keyof LoginState>);
  };

  handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const { username, password } = this.state;

    try {
      const response = await AuthServices.Login({ username, password });
      if (response && response.token) {
        const token = response.token;
        saveToken(token);
        alert("Login successful!");

        // Navigate to staff page
        this.props.navigate(ROUTE.Home);
      } else {
        this.setState({ error: "Invalid username or password" });
      }
    } catch (error) {
      this.setState({ error: "Invalid username or password" });
    }
  };

  render() {
    const { username, password, error } = this.state;

    return (
      <div className="login-container">
        <h2>Login</h2>
        <form onSubmit={this.handleSubmit}>
          <div>
            <label htmlFor="username">Username </label>
            <input
              type="text"
              name="username"
              id="username"
              value={username}
              onChange={this.handleInputChange}
              required
            />
          </div>
          <div>
            <label htmlFor="password">Password </label>
            <input
              type="password"
              name="password"
              id="password"
              value={password}
              onChange={this.handleInputChange}
              required
            />
          </div>
          {error && <p style={{ color: "red" }}>{error}</p>}
          <button type="submit">Login</button> &nbsp;
          <button onClick={() => this.props.navigate(ROUTE.Register)}>
            Register
          </button>
        </form>
      </div>
    );
  }
}

export default withNavigate(LoginComponent);
