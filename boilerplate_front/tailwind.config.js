module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui'],
        heading: ['Sarabun', 'sans-serif']
      },
      colors: {
        primary: '#2D2E77',
        textColor: '#111928',
        outlined: '#ECEAF4',
        success: '#22C55E',
        warning: '#F97316',
        danger: '#EF4444',
        text: {
          primary: '#111928',
          secondary: '#5A6476',
          light: '#5A6476'
        },
        gray: {
          50: '#f9fafb',
          100: '#f3f4f6',
          150: '#eeeeee',
          200: '#e5e7eb',
          300: '#d1d5db',
          400: '#9ca3af',
          500: '#6b7280',
          600: '#4b5563',
          700: '#374151',
          800: '#1f2937',
          900: '#111827'
        },
        surface: {
          a: '#ffffff',
          b: '#f9fafb',
          c: '#f3f4f6',
          d: '#e5e7eb',
          e: '#ffffff',
          f: '#ffffff',
          ground: '#f9fafb',
          section: '#ffffff',
          card: '#ffffff',
          overlay: '#ffffff',
          border: '#dfe7ef',
          hover: '#f6f9fc',
          divider: '#BDBDBD'
        },
        maskBg: 'rgba(0, 0, 0, 0.4)',
      },
      spacing: {
        inline: '0.5rem',
        content: '1.25rem'
      },
      backgroundImage: {
      }
    }
  },
  plugins: [require('tailwindcss-primeui')]
}
