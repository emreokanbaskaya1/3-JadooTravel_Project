// Dil y�netimi i�in JavaScript
class I18n {
    constructor() {
        this.currentLanguage = localStorage.getItem('jadoo_language') || 'en';
        this.translations = {};
        this.supportedLanguages = {
            'en': { name: '???? English', code: 'EN' },
            'tr': { name: '???? Turkish', code: 'TR' },
            'es': { name: '???? Spanish', code: 'ESP' },
            'fr': { name: '???? French', code: 'FR' }
        };
        this.init();
    }

    async init() {
        await this.loadTranslations();
        this.updateUI();
        this.setupEventListeners();
    }

    async loadTranslations() {
        try {
            const response = await fetch(`/locales/${this.currentLanguage}.json`);
            if (response.ok) {
                this.translations = await response.json();
            } else {
                console.error('Translation file not found:', this.currentLanguage);
                // Fallback to English if translation file not found
                if (this.currentLanguage !== 'en') {
                    this.currentLanguage = 'en';
                    await this.loadTranslations();
                }
            }
        } catch (error) {
            console.error('Error loading translations:', error);
        }
    }

    translate(path) {
        const keys = path.split('.');
        let value = this.translations;
        
        for (const key of keys) {
            if (value && typeof value === 'object' && key in value) {
                value = value[key];
            } else {
                return path; // Return original path if translation not found
            }
        }
        
        return value || path;
    }

    async changeLanguage(language) {
        if (this.supportedLanguages[language]) {
            this.currentLanguage = language;
            localStorage.setItem('jadoo_language', language);
            await this.loadTranslations();
            this.updateUI();
        }
    }

    updateUI() {
        // Navbar dil g�stergesini g�ncelle
        const languageBadge = document.querySelector('.navbar .badge');
        if (languageBadge) {
            languageBadge.textContent = this.supportedLanguages[this.currentLanguage].code;
        }

        // Dropdown aktif se�ene�i g�ncelle
        this.updateLanguageDropdown();

        // T�m �eviri elementlerini g�ncelle
        this.updateTranslatedElements();

        // Navbar linklerini g�ncelle
        this.updateNavbarLinks();
    }

    updateLanguageDropdown() {
        const dropdownItems = document.querySelectorAll('.dropdown-menu .dropdown-item');
        dropdownItems.forEach(item => {
            item.classList.remove('active', 'fw-bold');
            const itemLang = item.getAttribute('data-lang');
            if (itemLang === this.currentLanguage) {
                item.classList.add('active', 'fw-bold');
            }
        });
    }

    updateNavbarLinks() {
        // Navbar link metinlerini g�ncelle
        document.querySelectorAll('.navbar-nav .nav-link').forEach(link => {
            const href = link.getAttribute('href');
            
            if (href === '#service') {
                link.textContent = this.translate('navbar.services');
            } else if (href === '#destination') {
                link.textContent = this.translate('navbar.locations');
            } else if (href === '#booking') {
                link.textContent = this.translate('navbar.reservation');
            } else if (href === '#testimonial') {
                link.textContent = this.translate('navbar.testimonials');
            } else if (link.textContent.includes('Login') || link.getAttribute('data-i18n') === 'navbar.login') {
                link.textContent = this.translate('navbar.login');
            }
        });

        // Get Info button
        const getInfoBtn = document.querySelector('.btn-outline-dark');
        if (getInfoBtn) {
            getInfoBtn.textContent = this.translate('navbar.getInfo');
        }
    }

    updateTranslatedElements() {
        // data-i18n attribute'u olan t�m elementleri g�ncelle
        document.querySelectorAll('[data-i18n]').forEach(element => {
            const key = element.getAttribute('data-i18n');
            const translation = this.translate(key);
            
            if (element.tagName === 'INPUT' && (element.type === 'text' || element.type === 'email' || element.type === 'tel')) {
                element.placeholder = translation;
            } else if (element.tagName === 'TEXTAREA') {
                element.placeholder = translation;
            } else if (element.tagName === 'INPUT' && element.type === 'submit') {
                element.value = translation;
            } else {
                element.textContent = translation;
            }
        });
    }

    setupEventListeners() {
        // Dil dropdown event listener'lar�
        document.querySelectorAll('.dropdown-item[data-lang]').forEach(item => {
            item.addEventListener('click', (e) => {
                e.preventDefault();
                const language = e.target.getAttribute('data-lang');
                this.changeLanguage(language);
            });
        });
    }

    getCurrentLanguage() {
        return this.currentLanguage;
    }

    getSupportedLanguages() {
        return this.supportedLanguages;
    }
}

// Global olarak kullan�labilir hale getir
window.i18n = new I18n();

// DOM y�klendi�inde ba�lat
document.addEventListener('DOMContentLoaded', () => {
    if (!window.i18n) {
        window.i18n = new I18n();
    }
});