/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        'healing-pink': '#fff1f2',
        'healing-rose': '#be123c',
        'healing-deep': '#7f1d1d',
      },
      fontFamily: {
        'serif': ['"Playfair Display"', 'serif'],
        'sans': ['Quicksand', 'sans-serif'],
      }
    },
  },
  plugins: [],
}