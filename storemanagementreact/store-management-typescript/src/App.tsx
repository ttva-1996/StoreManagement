// src/App.tsx
import { Component } from "react";
import StaffComponent from "./pages/staff/StaffComponent";
import LoginComponent from "./pages/auth/LoginComponent";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { ROUTE } from "./constants/route.constant";
import HomeComponent from "./pages/home/HomeComponent";
import RegisterComponent from "./pages/auth/RegisterComponent";

interface AppProps {
  title: string;
}

interface AppState {
  counter: number;
}

class App extends Component<AppProps, AppState> {
  constructor(props: AppProps) {
    super(props);
    this.state = {
      counter: 0,
    };
  }

  incrementCounter = () => {
    this.setState({ counter: this.state.counter + 1 });
  };
  render() {
    return (
      <Router>
        <Routes>
          <Route path={ROUTE.Home} element={<HomeComponent />} />
          <Route path={ROUTE.Login} element={<LoginComponent />} />
          <Route path={ROUTE.Register} element={<RegisterComponent />} />
          <Route path={ROUTE.Staff} element={<StaffComponent />} />
        </Routes>
      </Router>
    );
  }
}

export default App;
