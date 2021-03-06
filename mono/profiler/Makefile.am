if HAVE_ZLIB
Z_LIBS= -lz
else
Z_LIBS=
endif

AM_CPPFLAGS = \
	-fexceptions -DMONO_USE_EXC_TABLES	\
	-DSUPPRESSION_DIR=\""$(datadir)/mono-$(API_VER)/mono/profiler"\"        \
	-I$(top_srcdir) 	\
	$(GLIB_CFLAGS)

if !HOST_WIN32
if !DISABLE_LIBRARIES
if !DISABLE_PROFILER
bin_PROGRAMS = mprof-report

if HAVE_VTUNE
vtune_lib = libmono-profiler-vtune.la
endif

lib_LTLIBRARIES = libmono-profiler-aot.la libmono-profiler-iomap.la libmono-profiler-log.la $(vtune_lib)

if PLATFORM_DARWIN
libmono_profiler_log_la_LDFLAGS = -Wl,-undefined -Wl,suppress -Wl,-flat_namespace
endif
if PLATFORM_ANDROID
libmono_profiler_log_la_LDFLAGS = -avoid-version
endif
endif
endif
endif

if HAVE_OPROFILE
# Do something that uses OPROFILE_CFLAGS and OPROFILE_LIBS
endif

if SUPPORT_BOEHM
if DISABLE_EXECUTABLES
LIBMONO=$(top_builddir)/mono/mini/$(LIBMONO_LA)
else
if !SHARED_MONO
static_libs=	\
	$(top_builddir)/mono/metadata/libmonoruntime-static.la	\
	$(top_builddir)/mono/io-layer/libwapi.la	\
	$(top_builddir)/mono/utils/libmonoutils.la \
	$(GLIB_LIBS) $(LIBICONV) \
	$(LIBGC_STATIC_LIBS)

LIBMONO=$(top_builddir)/mono/mini/$(LIBMONO_LA) $(static_libs)
else
LIBMONO=$(top_builddir)/mono/mini/$(LIBMONO_LA)
endif
endif
else
LIBMONO=$(top_builddir)/mono/mini/libmonosgen-$(API_VER).la
endif

libmono_profiler_aot_la_SOURCES = mono-profiler-aot.c
libmono_profiler_aot_la_LIBADD = $(LIBMONO) $(GLIB_LIBS) $(LIBICONV)
libmono_profiler_iomap_la_SOURCES = mono-profiler-iomap.c
libmono_profiler_iomap_la_LIBADD = $(LIBMONO) $(GLIB_LIBS) $(LIBICONV)
libmono_profiler_log_la_SOURCES = proflog.c
libmono_profiler_log_la_LIBADD = $(LIBMONO) $(GLIB_LIBS) $(Z_LIBS)
if HAVE_VTUNE
libmono_profiler_vtune_la_SOURCES = mono-profiler-vtune.c
libmono_profiler_vtune_la_CFLAGS = $(VTUNE_CFLAGS)
libmono_profiler_vtune_la_LIBADD = $(VTUNE_LIBS) $(LIBMONO) $(GLIB_LIBS) $(LIBICONV)
endif

mprof_report_SOURCES = decode.c
mprof_report_LDADD = $(Z_LIBS) $(GLIB_LIBS) $(LIBICONV)

PLOG_TESTS_SRC=test-alloc.cs test-busy.cs test-monitor.cs test-excleave.cs \
	test-heapshot.cs test-traces.cs
PLOG_TESTS=$(PLOG_TESTS_SRC:.cs=.exe)

-include $(mcs_topdir)/build/config.make

CLASS=$(mcs_topdir)/class/lib/$(DEFAULT_PROFILE)

with_mono_path = MONO_PATH=$(CLASS)

RUNTIME = $(with_mono_path) $(top_builddir)/runtime/mono-wrapper
MCS = $(RUNTIME) $(mcs_topdir)/class/lib/build/mcs.exe -unsafe -nowarn:0162 -nowarn:0168 -nowarn:0219 -debug

%.exe: %.cs
	$(MCS) -out:$@ $<

testlog: $(PLOG_TESTS)
	$(with_mono_path) perl $(srcdir)/ptestrunner.pl $(top_builddir)

if NACL_CODEGEN
check-local:
else
check-local: testlog
endif

suppressiondir = $(datadir)/mono-$(API_VER)/mono/profiler
suppression_DATA = mono-profiler-log.suppression

EXTRA_DIST=utils.c utils.h proflog.h perf_event.h \
	$(PLOG_TESTS_SRC) ptestrunner.pl \
	$(suppression_DATA)
