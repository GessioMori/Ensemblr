import { defineConfig, loadEnv } from 'vite';
import plugin from '@vitejs/plugin-react';
import mkcert from 'vite-plugin-mkcert'

export default defineConfig(({ mode }) => {
    const env = loadEnv(mode, process.cwd(), '');

    return {
        plugins: [plugin(), mkcert()],
        server: {
            port: parseInt(env.VITE_PORT),
        }
    }
})