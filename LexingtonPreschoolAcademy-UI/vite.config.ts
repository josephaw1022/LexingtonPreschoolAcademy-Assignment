// import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import "dotenv/config";
import { defineConfig, loadEnv } from "vite";
import process from "process";

// https://vitejs.dev/config/
export default defineConfig(({ command, mode }) => {
  const env = loadEnv(mode, process.cwd(), "");


  console.log("env.base_web_api_url", env['WEB_API_BASE_URL'])

  return {
    plugins: [vue()],
    define: {
      process: {
        env:  { 
          BASE_WEB_API_URL: JSON.stringify(env.BASE_WEB_API_URL),
        }
      },
    },
  };
});
