import { NavLink, Outlet } from 'react-router-dom'

export const Layout = () =>  {

return (   
        <>
            <header className='header'>
                <NavLink to='/' > Домашняя страница </NavLink>
                <NavLink to='lessons' > Список уроков </NavLink>
            </header>
            <main>
                <Outlet />
            </main>
            <footer className='footer'>footer</footer>
        </>       
    )
}